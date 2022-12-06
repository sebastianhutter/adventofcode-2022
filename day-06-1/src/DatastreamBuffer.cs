namespace Datastream {
    public class Buffer {
        private string rawMessage;
        private string markerChars;
        private int markerPosition;

        public Buffer(string m) {
            rawMessage = m;
            markerPosition = findMarkerPositionInRawMessage();
            markerChars = rawMessage.Substring(markerPosition-4,4);
        }

        private int findMarkerPositionInRawMessage() {
            for(int i=3; i<rawMessage.Length; i++) {
                string possibleMarker = rawMessage.Substring(i-3,4);
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

        public int getMarkerPosition() {
            return markerPosition;
        }

        public string getMarkerChars() {
            return markerChars;
        }
    }
}
