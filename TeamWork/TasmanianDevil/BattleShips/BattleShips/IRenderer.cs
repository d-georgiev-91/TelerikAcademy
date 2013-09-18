namespace BattleShips
{
    public interface IRenderer
    {
        void AddForRendering(IRendable item);
        void RenderAll();
        void ClearQueue();
    }
}
