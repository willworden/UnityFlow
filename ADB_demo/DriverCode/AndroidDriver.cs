using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Managed.Adb;
using NUnit.Framework;

namespace ADB_demo.DriverCode
{

    class AndroidDriver
    {
        AndroidDebugBridge mADB;
        String mAdbPath;
        List<Device> devices;

        public AndroidDriver()
        {
            //devices = AdbHelper.Instance.GetDevices(AndroidDebugBridge.SocketAddress);
//            mAdbPath = @;
            mADB = AndroidDebugBridge.CreateBridge("C:\\adb\\adb.exe", true);
            mADB.Start();
            Thread.Sleep(1000);

            var list = mADB.Devices;
            Console.WriteLine("DEVICES: " + list.Count);
        }

        public void printHelloWorld()
        {
            Console.WriteLine("Hello World");
        }

        public void installApplication(string installFile)
        {
            var Device = mADB.Devices[0];
            var tmp = @"C:\tmp\Redstone_Dev_Android.apk";
            ISyncProgressMonitor monitor = new NullSyncProgressMonitor();
            
            Assert.That(Device.BusyBox.Available);

            string format = Directory.GetCurrentDirectory() + installFile;
            Console.WriteLine(format);
            Console.WriteLine("Starting upload...");
            Console.WriteLine();
            if (File.Exists(tmp))
            {

                //MOUNT NEEDED?
                var mountpoints = Device.MountPoints;
                MountPoint target=null;
                foreach (var point in mountpoints)
                {
                    
                    Console.WriteLine(point.ToString());
//                    if (point.ToString().Contains(@"/dev, tmpfs"))
//                    {
//                        target = mountpoints[point.Key];
//                        break;
//                    }
                }
//                Device.FileSystem.Mount(target);
 //                Device.FileSystem.Mount("/dev/blocl/stl9 /system");
//                Device.FileSystem.Chmod("/", );
                var result =  Device.SyncService.PushFile(format, "/data/local/test.apk", monitor);
                Console.WriteLine("RESULT" +result.Message);
//                Console.WriteLine("Trying " + tmp);
////                Device.FileSystem.Exists(@"/sdcard/tmp/");
////                var result = Device.SyncPackageToDevice(tmp);
//                Console.WriteLine(result);
//
//                Console.WriteLine("Done uploading....");
//                Console.WriteLine("Starting installation...");
//                Device.InstallPackage(installFile.Split('\\')[0], true);
//                Console.WriteLine("Done installation...");
            }
            else
            {
                Assert.Fail("no file");
            }
        }

        public void Stop()
        {
            mADB.Stop();
        }
    }
}
