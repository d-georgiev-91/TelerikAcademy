using System;
using System.Collections.Generic;

namespace BattleShips
{
    class ConsoleRenderer : IRenderer
    {
        List<IRendable> list;
        
        public ConsoleRenderer()
        {
            this.list = new List<IRendable>();
        }

        public void AddForRendering(IRendable item)
        {
            list.Add(item);
        }

        public void RenderAll()
        {
            foreach (var item in list)
            {
                item.Draw();
            }
        }

        public void ClearQueue()
        {
            this.list = new List<IRendable>();
        }
    }
}