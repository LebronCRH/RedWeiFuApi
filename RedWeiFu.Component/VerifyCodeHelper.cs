using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace RedWeiFu.Component
{
   public class VerifyCodeHelper
    {
        public static string HZ;

        /// <summary>
        /// 验证码的最大长度
        /// </summary>
        public int MaxLength
        {
            get { return 10; }
        }
        /// <summary>
        /// 验证码的最小长度
        /// </summary>
        public int MinLength
        {
            get { return 1; }
        }

        protected string GetVerifyCode()
        {
            string[] str = CreateValidateNumber(5);

            string strcode = string.Empty;

            for (int i = 0; i < str.Length; i++)
            {
                strcode += str[i];
            }
            HZ = strcode;
            return HZ;
        }

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <param name="length">指定验证码的长度</param>
        /// <returns>验证码</returns>
        public string[] CreateValidateNumber(int length)
        {
            string Vchar = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p" +
            ",q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q" +
            ",R,S,T,U,V,W,X,Y,Z";

            string[] VcArray = Vchar.Split(new Char[] { ',' });//拆分成数组
            string[] num = new string[length];

            int temp = -1;//记录上次随机数值，尽量避避免生产几个一样的随机数

            Random rand = new Random();
            //采用一个简单的算法以保证生成随机数的不同
            for (int i = 1; i < length + 1; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));
                }

                int t = rand.Next(61);
                if (temp != -1 && temp == t)
                {
                    return CreateValidateNumber(length);

                }
                temp = t;
                num[i - 1] = VcArray[t];
                //num.SetValue(VcArray[t]);
                //VNum += VcArray[t];
            }
            return num;
        }
    }
}
