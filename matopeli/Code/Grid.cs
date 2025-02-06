using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Godot;

namespace SnakeGame
{
	public partial class Grid : Node2D
	{
		[Export] private string _cellScenePath = "res://Levels/Cell.tscn";
		[Export] private int _width = 0;
		[Export] private int _height = 0;
		private int cellpos;

		// Vector2I on integeriä kullekin koordinaatille yksikkönä käyttävä vektorityyppi.
		[Export] private Vector2I _cellSize = Vector2I.Zero;

		// TODO: Kirjoita julkinen property, joka mahdollistaa _width jäsenmuuttujan lukemisen,
		// muttei asettamista. Anna propertyn nimeksi Width.
		public int Width
		{
			get {return _width;}
		}

		// TODO: Kirjoita vastaava property _height jäsenmuuttujalle. Propertyn nimi tulee olla Height.

		public int Height
		{
			get {return _height;}
		}


		// Tähän 2-uloitteiseen taulukkoon on tallennettu gridin solut. Alussa taulukkoa ei ole, vaan
		// muuttujassa on tyhjä viittaus (null). Taulukko pitää luoda pelin alussa (esim. _Ready-metodissa).
		private Cell[,] _cells = null;

		public override void _Ready()
		{
			// TODO: Alusta _cells taulukko
			int [,] _cells = new int [15,13]
			{
				{1,2,3,4,5,6,7,8,9,10,11,12,13},
				{14,15,16,17,18,19,20,21,22,23,24,25,26},
				{27,28,29,30,31,32,33,34,35,36,37,38,39},
				{40,41,42,43,44,45,46,47,48,49,50,51,52},
				{53,54,55,56,57,58,59,60,61,62,63,64,65},
				{66,67,68,69,70,71,72,73,74,75,76,77,78},
				{79,80,81,82,83,84,85,86,87,88,89,90,91},
				{92,93,94,95,96,97,98,99,100,101,102,103,104},
				{105,106,107,108,109,110,111,112,113,114,115,116,117},
				{118,119,120,121,122,123,124,125,126,127,128,129,130},
				{131,132,133,134,135,136,137,138,139,140,141,142,143},
				{144,145,146,147,148,149,150,151,152,153,154,155,156},
				{157,158,159,160,161,162,163,164,165,166,167,168,169},
				{170,171,172,173,174,175,176,177,178,179,180,181,182},
				{183,184,185,186,187,188,189,190,191,192,193,194,195}
			};

			// Laske se piste, josta taulukon rakentaminen aloitetaan. Koska 1. solu luodaan gridin vasempaan
			// yläkulmaan, on meidän laskettava sitä koordinaattia vastaava piste. Oletetaan Gridin pivot-pisteen
			// olevan kameran keskellä (https://en.wikipedia.org/wiki/Pivot_point).
			Vector2 offset = new Vector2((_width * _cellSize.X) / 2, (_height * _cellSize.Y) / 2);

			// Lataa Cell-scene. Luomme tästä uuden olion kutakin ruutua kohden.
			PackedScene cellScene = ResourceLoader.Load<PackedScene>(_cellScenePath);
			if (cellScene == null)
			{
				GD.PrintErr("Cell sceneä ei löydy! Gridiä ei voi luoda!");
				return;
			}
			// Alustetaan Grid kahdella sisäkkäisellä for-silmukalla.
			for (int x = 0; x < _width; ++x)
			{
				for (int y = 0; y < _height; ++y)
				{
					// Luo uusi olio Cell-scenestä.
					Cell cell = cellScene.Instantiate<Cell>();
					// Lisää juuri luotu Cell-olio gridin Nodepuuhun.
					AddChild(cell);

                    // TODO: Laske ja aseta ruudun sijainti niin maailman koordinaatistossa kuin
                    // ruudukonkin koordinaatistossa. Aseta ruudun sijainti käyttäen cell.Position propertyä.
					GD.Print(_cells[x,y]);
					cellpos = _cells[x,y];
					// TODO: Tallenna ruutu tietorakenteeseen oikealle paikalle.
				}
			}
		}
	}
}