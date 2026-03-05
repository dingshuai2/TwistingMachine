using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using Modbus.Device;

namespace TwistingMachine.CommHelpers
{
    /// <summary>
    /// Modbus TCP 客户端助手类，用于实现 Modbus TCP 协议通信
    /// </summary>
    public class ModbusTcpClientHelper : IDisposable
    {
        /// <summary>
        /// TCP 客户端对象
        /// </summary>
        private TcpClient? _tcpClient;
        
        /// <summary>
        /// Modbus 主站对象
        /// </summary>
        private IModbusMaster? _modbusMaster;
        
        /// <summary>
        /// 连接状态
        /// </summary>
        private bool _isConnected;

        /// <summary>
        /// 获取连接状态
        /// </summary>
        public bool IsConnected => _isConnected;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ModbusTcpClientHelper() { }

        /// <summary>
        /// 异步连接到 Modbus TCP 设备
        /// </summary>
        /// <param name="ipAddress">设备 IP 地址</param>
        /// <param name="port">设备端口号</param>
        /// <returns>连接是否成功</returns>
        public async Task<bool> ConnectAsync(string ipAddress, int port)
        {
            try
            {
                _tcpClient = new TcpClient();
                await _tcpClient.ConnectAsync(ipAddress, port);
                _modbusMaster = ModbusIpMaster.CreateIp(_tcpClient);
                _isConnected = true;
                return true;
            }
            catch (Exception ex)
            {
                _isConnected = false;
                throw new ModbusException($"连接失败: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        public void Disconnect()
        {
            try
            {
                if (_modbusMaster != null)
                {
                    (_modbusMaster as IDisposable)?.Dispose();
                }
                if (_tcpClient != null)
                {
                    _tcpClient.Close();
                    _tcpClient.Dispose();
                }
                _isConnected = false;
            }
            catch (Exception ex)
            {
                throw new ModbusException($"断开连接失败: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// 读取保持寄存器
        /// </summary>
        /// <param name="slaveId">从站 ID</param>
        /// <param name="startAddress">起始地址</param>
        /// <param name="count">寄存器数量</param>
        /// <returns>寄存器值数组</returns>
        public ushort[] ReadHoldingRegisters(byte slaveId, ushort startAddress, ushort count)
        {
            try
            {
                if (!_isConnected || _modbusMaster == null)
                {
                    throw new ModbusException("客户端未连接");
                }
                return _modbusMaster.ReadHoldingRegisters(slaveId, startAddress, count);
            }
            catch (Exception ex)
            {
                throw new ModbusException($"读取保持寄存器失败: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// 读取输入寄存器
        /// </summary>
        /// <param name="slaveId">从站 ID</param>
        /// <param name="startAddress">起始地址</param>
        /// <param name="count">寄存器数量</param>
        /// <returns>寄存器值数组</returns>
        public ushort[] ReadInputRegisters(byte slaveId, ushort startAddress, ushort count)
        {
            try
            {
                if (!_isConnected || _modbusMaster == null)
                {
                    throw new ModbusException("客户端未连接");
                }
                return _modbusMaster.ReadInputRegisters(slaveId, startAddress, count);
            }
            catch (Exception ex)
            {
                throw new ModbusException($"读取输入寄存器失败: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// 读取线圈
        /// </summary>
        /// <param name="slaveId">从站 ID</param>
        /// <param name="startAddress">起始地址</param>
        /// <param name="count">线圈数量</param>
        /// <returns>线圈状态数组</returns>
        public bool[] ReadCoils(byte slaveId, ushort startAddress, ushort count)
        {
            try
            {
                if (!_isConnected || _modbusMaster == null)
                {
                    throw new ModbusException("客户端未连接");
                }
                return _modbusMaster.ReadCoils(slaveId, startAddress, count);
            }
            catch (Exception ex)
            {
                throw new ModbusException($"读取线圈失败: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// 读取离散输入
        /// </summary>
        /// <param name="slaveId">从站 ID</param>
        /// <param name="startAddress">起始地址</param>
        /// <param name="count">输入数量</param>
        /// <returns>离散输入状态数组</returns>
        public bool[] ReadInputs(byte slaveId, ushort startAddress, ushort count)
        {
            try
            {
                if (!_isConnected || _modbusMaster == null)
                {
                    throw new ModbusException("客户端未连接");
                }
                return _modbusMaster.ReadInputs(slaveId, startAddress, count);
            }
            catch (Exception ex)
            {
                throw new ModbusException($"读取离散输入失败: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// 写入单个寄存器
        /// </summary>
        /// <param name="slaveId">从站 ID</param>
        /// <param name="registerAddress">寄存器地址</param>
        /// <param name="value">写入值</param>
        public void WriteSingleRegister(byte slaveId, ushort registerAddress, ushort value)
        {
            try
            {
                if (!_isConnected || _modbusMaster == null)
                {
                    throw new ModbusException("客户端未连接");
                }
                _modbusMaster.WriteSingleRegister(slaveId, registerAddress, value);
            }
            catch (Exception ex)
            {
                throw new ModbusException($"写入单个寄存器失败: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// 写入多个寄存器
        /// </summary>
        /// <param name="slaveId">从站 ID</param>
        /// <param name="startAddress">起始地址</param>
        /// <param name="values">写入值数组</param>
        public void WriteMultipleRegisters(byte slaveId, ushort startAddress, ushort[] values)
        {
            try
            {
                if (!_isConnected || _modbusMaster == null)
                {
                    throw new ModbusException("客户端未连接");
                }
                _modbusMaster.WriteMultipleRegisters(slaveId, startAddress, values);
            }
            catch (Exception ex)
            {
                throw new ModbusException($"写入多个寄存器失败: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// 写入单个线圈
        /// </summary>
        /// <param name="slaveId">从站 ID</param>
        /// <param name="coilAddress">线圈地址</param>
        /// <param name="value">线圈状态</param>
        public void WriteSingleCoil(byte slaveId, ushort coilAddress, bool value)
        {
            try
            {
                if (!_isConnected || _modbusMaster == null)
                {
                    throw new ModbusException("客户端未连接");
                }
                _modbusMaster.WriteSingleCoil(slaveId, coilAddress, value);
            }
            catch (Exception ex)
            {
                throw new ModbusException($"写入单个线圈失败: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// 写入多个线圈
        /// </summary>
        /// <param name="slaveId">从站 ID</param>
        /// <param name="startAddress">起始地址</param>
        /// <param name="values">线圈状态数组</param>
        public void WriteMultipleCoils(byte slaveId, ushort startAddress, bool[] values)
        {
            try
            {
                if (!_isConnected || _modbusMaster == null)
                {
                    throw new ModbusException("客户端未连接");
                }
                _modbusMaster.WriteMultipleCoils(slaveId, startAddress, values);
            }
            catch (Exception ex)
            {
                throw new ModbusException($"写入多个线圈失败: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            Disconnect();
            GC.SuppressFinalize(this);
        }
    }

    /// <summary>
    /// Modbus 异常类
    /// </summary>
    public class ModbusException : Exception
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">异常消息</param>
        public ModbusException(string message) : base(message)
        {}

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">异常消息</param>
        /// <param name="innerException">内部异常</param>
        public ModbusException(string message, Exception innerException) : base(message, innerException)
        {}
    }
}
