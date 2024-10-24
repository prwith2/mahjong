using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mahjongfingertip.Models
{
    public class Partida
    {
        public long Id { get; set; }
        public long Jogador1Id { get; set; }
        public long Jogador2Id { get; set; }
        public string Estado { get; set; }
    }
}
