using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPlayerPro.EasyPlayerPro
{
	public interface IPlayer
	{
		void Play();
		void Pause();
		void Stop();
		void SetBounds(int x,int y,int width, int height);
		void SnapShot(string file, int width = 0, int height = 0, int waitTime = 0);

	}
}
