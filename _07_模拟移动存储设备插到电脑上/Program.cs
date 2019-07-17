using System;
using System.Collections;

namespace _07_模拟移动存储设备插到电脑上
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
             *  模拟U盘、移动硬盘、MP3插在电脑上
             *  特征：U盘、移动硬盘、MP3都有读写功能（Read()、Write())
             *  三者都要插到电脑上，才能被电脑调用其读写功能
             *  电脑：有调用U盘等存储设备读写的功能（
             */
            //Computer computer = new Computer();
            //MP3 mp3 = new MP3();
            //UDisk uDisk = new UDisk();
            //MobileDisk mobileDisk = new MobileDisk();

            //computer.

            //computer.RRead();
            //computer.WWrite();
            //Console.ReadKey();

            Computer computer = new Computer();
            string[] operations = { "插入", "查看", "移除", "移除全部", "读取", "写入", "退出", "清屏" };
            string[] okey = { "1", "2", "3", "4", "5", "6", "7", "8" };
            while (true)
            {
                bool isEnd;   // 是否退出标志
                // 打印提示消息
                Console.Write("请选择你要执行的操作：");
                for (int i = 0; i < operations.Length; i++)
                {
                    Console.Write("{0}：{1} ", i + 1, operations[i]);
                }

                Console.WriteLine();
                string input = Console.ReadLine();
                // 输入错误  输入的不是1-5或"插入", "查看", "移除", "读","写", "退出" 
                if (!(DealArray.StrInStrArray(input, operations)) && !(DealArray.StrInStrArray(input, okey)))
                {
                    Console.WriteLine("输入错误，请重新选择");
                    continue;
                }
                else
                {
                    ChoiceOperation(input, out isEnd);   // 选择操作
                }

                if (isEnd)   // 判断是否退出
                {
                    break;
                }
            }

            void ChoiceOperation(string operation, out bool isEnd)
            {
                isEnd = false;
                switch (operation)
                {
                    case "1":
                    case "插入":
                        Console.WriteLine("请输入你要插入的设备");
                        string input2 = Console.ReadLine();
                        Insertion(input2);
                        break;
                    case "2":
                    case "查看":
                        Check();
                        break;
                    case "3":
                    case "移除":
                        if (Check())
                        {
                            Console.Write("请输入你要移除的设备名：");
                            string delDevice = Console.ReadLine();
                            computer.RemoveUsbDevice(delDevice);
                        }
                        else
                        {
                            Console.WriteLine("无设备可移除");
                        }

                        break;
                    case "4":
                    case "移除全部":
                        computer.RemoveAllDevice();
                        break;
                    case "5":
                    case "读取":
                        computer.RRead();
                        break;
                    case "6":
                    case "写入":
                        computer.WWrite();
                        break;
                    case "7":
                    case "退出":
                        isEnd = true;
                        break;
                    case "8":
                    case "清屏":
                        Console.Clear();
                        break;
                }
            }

            bool Check()
            {
                Hashtable devices = computer.GetUSBDevices();
                if (devices.Count > 0)
                {
                    Console.Write("当前的连接数{0}，", devices.Count);
                    Console.Write("当前连接的设备有：");
                    foreach (var item in devices.Keys)
                    {
                        Console.Write("{0} ", item);
                    }
                    Console.WriteLine();
                    return true;
                }
                else
                {
                    Console.WriteLine("暂无连接");
                    return false;
                }
            }
            void Insertion(string insertItem)
            {
                switch (insertItem)
                {
                    case "U盘":
                    case "u盘":
                        computer.AddUsbDevices(insertItem, new UDisk());
                        break;
                    case "移动硬盘":
                        computer.AddUsbDevices(insertItem, new MobileDisk());
                        break;
                    case "Mp3":
                    case "MP3":
                    case "mp3":
                        computer.AddUsbDevices(insertItem, new MP3());
                        break;
                    default:
                        computer.AddUsbDevices(insertItem, new OtherDevice());
                        break;
                }
            }
            //Console.ReadKey();





        }


        //string[] strs = { "a", "b" };
        //string str = Console.ReadLine();
        //Console.WriteLine(!DealArray.StrInStrArray(str, strs));
        //Console.ReadKey();
        
    }
}

#region 几种移动设备类 U盘 移动硬盘 MP3
/// <summary>
/// 移动存储设备 抽象类
/// </summary>
public abstract class USBDevice
{
    public abstract void Read();
    public abstract void Write();
}

public class UDisk : USBDevice
{
    public override void Read()
    {
        Console.WriteLine("U盘读数据");
    }

    public override void Write()
    {
        Console.WriteLine("U盘写数据");
    }
}

public class MobileDisk : USBDevice
{
    public override void Read()
    {
        Console.WriteLine("移动硬盘读数据");
    }

    public override void Write()
    {
        Console.WriteLine("移动硬盘写数据");
    }
}

public class MP3 : USBDevice
{
    public override void Read()
    {
        Console.WriteLine("Mp3读数据");
    }

    public override void Write()
    {
        Console.WriteLine("Mp3写数据");
    }

    public void PlayMusic()
    {
        Console.WriteLine("播放音乐");
    }
}

public class OtherDevice : USBDevice
{
    public override void Read()
    {
        Console.WriteLine("其他设备读数据");
    }

    public override void Write()
    {
        Console.WriteLine("其他设备写数据");
    }
}
#endregion

public class Computer
{
    // 添加一个Hashtable变量，用来存储插入的存储设备
    private Hashtable _usbDevices = new Hashtable();

    // 根据key-value添加一个存储设备  最大可以连3个
    public void AddUsbDevices(string deviceName, USBDevice uSBDevice)
    {
        if (_usbDevices.Count > 2)
        {
            Console.WriteLine("连接失败，当前连接数已达到最大");
        }
        else
        {
            _usbDevices.Add(deviceName, uSBDevice);
            Console.WriteLine("插入设备{0}成功", deviceName);
        }
    }

    // 根据设备名，拔掉设备
    public void RemoveUsbDevice(string deviceName)
    {
        if (_usbDevices.ContainsKey(deviceName))
        {
            _usbDevices.Remove(deviceName);
            Console.WriteLine("移除设备{0}成功", deviceName);
        }
        else
        {
            Console.WriteLine("没有插入此设备，移除失败");
        }

    }

    // 获得当前插入的设备总数
    public int getUsbDeviceNum()
    {
        return _usbDevices.Count;
    }

    // 获得当前所有插入的设备
    public Hashtable GetUSBDevices()
    {
        return _usbDevices;
    }

    // 清空所有设备
    public void RemoveAllDevice()
    {
        _usbDevices.Clear();
        Console.WriteLine("移除所有设备成功");
    }


    // 读取所有设备
    public void RRead()
    {
        if (getUsbDeviceNum() > 0)
        {
            Console.WriteLine("当前正在有{0}个设备连接", getUsbDeviceNum());
            Hashtable usbDevices = GetUSBDevices();
            foreach (var item in usbDevices.Keys)
            {
                ((USBDevice)usbDevices[item]).Read();
            }
        }
        else
        {
            Console.WriteLine("暂无设备可读取");
        }

    }

    // 写入所有设备
    public void WWrite()
    {
        if (getUsbDeviceNum() > 0)
        {
            Console.WriteLine("当前正在有{0}个设备连接", getUsbDeviceNum());
            Hashtable usbDevices = GetUSBDevices();
            foreach (var item in usbDevices.Keys)
            {
                ((USBDevice)usbDevices[item]).Write();
            }
        }
        else
        {
            Console.WriteLine("暂无设备可写入");
        }

    }
}

/// <summary>
/// 这是一个处理数组的工具类
/// </summary>
public static class DealArray
{
    /// <summary>
    /// 判断字符串是否在字符串数组中
    /// </summary>
    /// <param name="str">字符串</param>
    /// <param name="strs">字符串数组</param>
    /// <returns>返回是否在字符串数组中</returns>
    public static bool StrInStrArray(string str, string[] strs)
    {
        for (int i = 0; i < strs.Length; i++)
        {
            if (str.Equals(strs[i]))
            {
                return true;
            }
        }
        return false;
    }
}
