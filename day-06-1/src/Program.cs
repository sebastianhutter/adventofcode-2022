using Input;
using Datastream;


namespace ConsoleApplication {
    class Program {
        static void Main(string[] args) {

            Parser rawMessages = new Parser("../input.txt");
            List<Datastream.Buffer> buffer = new List<Datastream.Buffer>();

            foreach(string m in rawMessages.getMessages()) {
                buffer.Add(new Datastream.Buffer(m));
            }
            
            Console.WriteLine(buffer[0].getPacketMarkerPosition());

        }
    }
}
