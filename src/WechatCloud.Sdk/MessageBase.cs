//
//  MessageBase.cs
//
//  Author:
//       lurongkai <lurongkai@gmail.com>
//
//  Copyright (c) 2013 lurongkai
//
//  This program is free software; you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation; either version 2 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program; if not, write to the Free Software
//  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
//
using System;
using System.IO;
using System.Text;

namespace WechatCloud.Sdk
{
    public abstract class MessageBase
    {
        public string ToUserName { get; protected set; }
        public string FromUserName { get; protected set; }
        public DateTimeOffset CreateTime { get; protected set; }

        public virtual string MsgType { get; protected set; }

        internal virtual void Rendering(Stream stream) {
            var serializer = Registry.Instance.Resolve<ISerializer>();
            var content = serializer.Serialize(this);

            var bytes = Encoding.Unicode.GetBytes(content);
            stream.Write(bytes, 0, bytes.Length);
        }
    }
}

