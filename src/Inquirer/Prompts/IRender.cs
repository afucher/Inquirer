namespace InquirerCore.Prompts
{
    public interface IRender
    {
        int[,] RenderMultipleMessages(string[] mensagens);
        void Clean(int initialPos, int endPos);
    }
}