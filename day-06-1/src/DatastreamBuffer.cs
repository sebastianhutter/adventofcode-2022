namespace Datastream {
    public class Buffer {
        private string rawMessage;
        private string packetMarkerChars;
        private int packetMarkerPosition;

        private int packetMarkerLength = 4;

        public Buffer(string m) {
            rawMessage = m;
            packetMarkerPosition = findMarkerPositionInRawMessage(packetMarkerLength);
            packetMarkerChars = rawMessage.Substring(packetMarkerPosition-packetMarkerLength,packetMarkerLength);
        }

        private int findMarkerPositionInRawMessage(int markerLength) {
            for(int i=markerLength-1; i<rawMessage.Length; i++) {
                string possibleMarker = rawMessage.Substring(i-(markerLength-1),markerLength);
                if (isMarkerUnique(possibleMarker)) {
                    return i+1;
                }                
            }
            return 0;
        }

        private bool isMarkerUnique(string m) {
            for (int i = 0; i < m.Length; i++) {
                for (int j = i + 1; j < m.Length; j++) {
                    if (m[i] == m[j]) {
                        return false;
                    }
                }
            }
            return true;
        }

        public int getPacketMarkerPosition() {
            return packetMarkerPosition;
        }

        public string getPacketMarkerChars() {
            return packetMarkerChars;
        }
    }
}
