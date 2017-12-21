using Starcounter;

namespace KitchenSink
{
    partial class TextPage : Json
    {
        public string NameReaction => string.IsNullOrEmpty(Name) ? "What's your name?" : $"Hi, {Name}!";

        public string NameLiveReaction => string.IsNullOrEmpty(NameLive) ? "What's your name?" : $"Hi, {NameLive}!";

        public string NameForPaperReaction => string.IsNullOrEmpty(NameForPaper) ? "What's your name?" : $"Hi, {NameForPaper}!";

        public string NameForPaperLiveReaction => string.IsNullOrEmpty(NameForPaperLive) ? "What's your name?" : $"Hi, {NameForPaperLive}!";

    }
}