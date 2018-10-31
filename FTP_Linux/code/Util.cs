using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTP_Linux.code
{
    class Util
    {
        public struct SshConnectionInfo
        {
            public string Host;
            public string User;
            public string Pass;
            public string IdentityFile;
        }
        public static SshConnectionInfo GetConnectionInfo(string Host,string User,string Pass,string IdentityFile)
		{
			SshConnectionInfo info = new SshConnectionInfo();
			info.Host = Host;
			info.User = User;
            info.Pass=Pass;
            info.IdentityFile=IdentityFile;
			return info;
		}





	}
    
}
