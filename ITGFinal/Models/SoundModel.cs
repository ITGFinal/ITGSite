using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ITGFinal.Models
{
    public class SoundModel
    {
        public bool IsTruth()
        {
            string answer = Convert.ToString(Post());

            if (answer == "хуйня из бд") //чек поля бд
            {
                return true;
            }
            else
            {



                return false;

            }

        }
        public async Task<string> Post()
        {

            //https://stt.api.cloud.yandex.net/speech/v1/stt:recogn..

            byte[] bytes = GetBinaryFile(@"C:\Users\Макс\source\repos\testConsole\testConsole\bin\Debug\netcoreapp3.1\English.ogg");

            var content = new ByteArrayContent(bytes);

            string answer;



            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://stt.api.cloud.yandex.net");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + "t1.9f7L7euelZrIzpKbyZDKyovJnZ6bkI2TieXz9304YAL67z8hN2b-3fP3PWddAvrvPyE3Zv4.wjfzB_0cu6dj3YozAZ2puOVY7EbLms5jXOGmLl0yf0urXmiRp2DHgCreAwD2NtjZ89gsihaM2xlnnLyDSPfDAQ");


            var response = client.PostAsync("speech/v1/stt:recognize?topic=general&lang=en-US&folderId=b1g0ujsjajgc33u371vv", content).Result;

            answer = await response.Content.ReadAsStringAsync();





            return answer;

        }


        private byte[] GetBinaryFile(string filename)
        {
            byte[] bytes;
            using (FileStream file = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                bytes = new byte[file.Length];
                file.Read(bytes, 0, (int)file.Length);
            }
            return bytes;
        }
    }
}
