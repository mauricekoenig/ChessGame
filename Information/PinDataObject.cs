
using System.Collections.Generic;

namespace MauriceKoenig.ChessGame
{
    public sealed class PinDataObject
    {
        public bool IsPinned { get; set; }
        public bool CanCaptureAttacker { get; set; }
        public BasePiece PinnedBy { get; set; }
        public List<Square> OptionalMoves;

        public PinDataObject (bool isPinned, bool canCapture, BasePiece pinnedBy, List<Square> optionalMoves) {

        }

    }
}
