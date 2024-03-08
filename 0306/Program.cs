using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0306
{
	class Elektronikaicikk
	{
		public static int db;
		protected int ar { get; set; }
		protected string nev { get; set; }
		protected int raktaron { get; set; }

		public int Ar
		{
			get => this.ar;
			set => this.ar = value;
		}
		public string Nev
		{
			get => this.nev;
			set => this.nev = value;
		}
		public int Raktaron
		{
			get => this.raktaron;
			set => this.raktaron = value;
		}

		public Elektronikaicikk(string nev, int ar, int raktaron)
		{
			this.nev = nev;
			this.ar = ar;
			this.raktaron = raktaron;
			db++;
			Kiir();
		}
		public Elektronikaicikk(string nev)
		{
			this.nev = nev;
			ar = 0;
			raktaron = 0;
			db++;
			Kiir();
		}

		protected virtual void Kiir()
		{
			Console.WriteLine($"{nev}, {ar}, {raktaron}");
		}

		public void Arufeltoltes()
		{
			int temp1 = 0;
			do
			{
				Console.WriteLine("Add meg a terméked árát!");
			} while ((!int.TryParse(Console.ReadLine(), out temp1) || (temp1 < 0)));
			this.Ar = temp1;
			temp1 = 0;
			do
			{
				Console.WriteLine("Add meg a terméked raktáron lévő mennyiségét!");
			} while ((!int.TryParse(Console.ReadLine(), out temp1) || (temp1 < 0)));
			this.Raktaron = temp1;
		}

		public void Vasarlas()
		{
			int darab = 0;
			do
			{
				Console.WriteLine("Add meg a vásárolni kívánt mennyiséget!");
			} while ((!int.TryParse(Console.ReadLine(), out darab) || (darab > this.Raktaron) || (darab < 0)));
			Console.WriteLine("A vásárlásod összege: " + darab * this.Ar);
			this.Raktaron = this.Raktaron - darab;
		}

	}

	class TV : Elektronikaicikk
	{
		private double atmero { get; }
		private double szelesseg { get; }

		public double Atmero
		{
			get => this.atmero;
		}
		public double Szelesseg
		{
			get => this.szelesseg;
		}

		public TV(string nev, double atmero, double szelesseg) : base(nev)
		{
			this.atmero = atmero;
			this.szelesseg = szelesseg;
			db++;
		}

		protected override void Kiir()
		{
			Console.WriteLine($"{nev}, {ar}, {raktaron}, {atmero}");
		}

		public double Magassag()
		{
			double magassag = Math.Pow(atmero, 2) - Math.Pow(szelesseg, 2);
			return Math.Sqrt(magassag);
		}
	}

	abstract class Alakazat
	{
		private string name { get; set; }
		protected double ter { get; set; }

		public double Ter
		{
			get => this.ter;
		}

		public Alakazat(string name)
		{
			this.name = name;
		}

		public double[] Olvas()
		{
			double[] oldalak;
			
			if (this.name == "KÖR")
			{
				oldalak = new double[1];
				for (int i = 0; i < oldalak.Length; i++)
				{
					double temp = 0;
					do
					{
						Console.WriteLine($"Add meg a kör sugarát!");
					} while (!double.TryParse(Console.ReadLine(), out temp));
					oldalak[i] = temp;
				}
			}
			else if (this.name == "TÉGLALAP")
			{
				oldalak = new double[2];
				Console.WriteLine("Add meg a téglalap adatait!");
				for (int i = 0; i < oldalak.Length; i++)
				{
					double temp = 0;
					do
					{
						Console.WriteLine($"Add meg a(z) {i+1}. oldalt!");
					} while (!double.TryParse(Console.ReadLine(), out temp));
					oldalak[i] = temp;
				}

			}
			else
			{
				oldalak = new double[3];
				Console.WriteLine("Add meg a háromszög adatait!");
				for (int i = 0; i < oldalak.Length; i++)
				{
					double temp = 0;
					do
					{
						Console.WriteLine($"Add meg a(z) {i+1}. oldalt!");
					} while (!double.TryParse(Console.ReadLine(), out temp));
					oldalak[i] = temp;
				}
			}
			

			return oldalak;
		}

		public abstract double Szamol(double[] oldalak);

		public virtual void Kiir()
		{
			Console.WriteLine("Az általános alakzatnak nincs területe!");
		}
	}

	class Kor : Alakazat
	{
		public Kor(string name) : base(name)
		{

		}

		public override double Szamol(double[] oldalak)
		{
			double sugar = oldalak[0];
			ter = Math.Pow(sugar, 2) * Math.PI;
			return ter;
		}

		public override void Kiir()
		{
			Console.WriteLine($"A kör területe : {this.Ter}");
		}
	}

	class Teglalap : Alakazat
	{
		public Teglalap(string name) : base(name)
		{

		}

		public override double Szamol(double[] oldalak)
		{
			double a = oldalak[0];
			double b = oldalak[1];
			ter = a * b;
			return ter;
		}

		public override void Kiir()
		{
			Console.WriteLine($"A téglalap területe : {this.Ter}");
		}
	}

	class Haromszog : Alakazat
	{
		public Haromszog(string name) : base(name)
		{
			
		}

		public override double Szamol(double[] oldalak)
		{
			double a = oldalak[0];
			double b = oldalak[1];
			double c = oldalak[2];
			double s = (a + b + c) / 2;
			ter = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
			return ter;
		}

		public override void Kiir()
		{
			Console.WriteLine($"A háromszög területe : {this.Ter}");
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			//1. feladat
			/*Elektronikaicikk eger = new Elektronikaicikk("Egér");
			eger.Arufeltoltes();
			eger.Vasarlas();

			TV teve = new TV("tévé", 140, 100);
			Console.WriteLine(teve.Magassag());*/

			//2. feladat
			Alakazat[] alakzatok = new Alakazat[3];
			List<string> jobevitel = new List<string> {"Kör", "kör", "Kor", "kor", "Téglalap", "téglalap", "teglalap", "Teglalap", "Háromszög", "háromszög", "haromszog", "Haromszog" };
			string tempbemenet = null;
			int hatralevo = 3;
			List<string> felvettek = new List<string>();
			do
			{
				tempbemenet = null;
				Console.WriteLine($"Adj meg egy tetszőleges alakzatot a következők közül: kör, téglalap vagy háromszög. Még {hatralevo} elemet adhatsz meg!");
				tempbemenet = Console.ReadLine();
				if (jobevitel.Contains(tempbemenet))
				{
					felvettek.Add(tempbemenet);
					hatralevo--;
				}
			} while (!jobevitel.Contains(tempbemenet) || (hatralevo > 0));

			for (int i = 0; i < felvettek.Count; i++)
			{
				felvettek[i] = felvettek[i].ToUpper();
			}

			List<double> teruletek = new List<double>();
			for (int i = 0; i < alakzatok.Length; i++)
			{
				if (felvettek[i] == "KÖR")
				{
					alakzatok[i] = new Kor(felvettek[i]);
					double[] oldalak = alakzatok[i].Olvas();
					alakzatok[i].Szamol(oldalak);
					teruletek.Add(alakzatok[i].Szamol(oldalak));
				}
				if (felvettek[i] == "TÉGLALAP")
				{
					alakzatok[i] = new Teglalap(felvettek[i]);
					double[] oldalak = alakzatok[i].Olvas();
					alakzatok[i].Szamol(oldalak);
					teruletek.Add(alakzatok[i].Szamol(oldalak));
				}
				if (felvettek[i] == "HÁROMSZÖG")
				{
					alakzatok[i] = new Haromszog(felvettek[i]);
					double[] oldalak = alakzatok[i].Olvas();
					alakzatok[i].Szamol(oldalak);
					teruletek.Add(alakzatok[i].Szamol(oldalak));
				}
			}

			Console.WriteLine("\nA felvett alakzatok adatai: ");
			for (int i = 0; i < alakzatok.Length; i++)
			{
				alakzatok[i].Kiir();
			}

			double legnagyobbkor = 0;
			double legnagyobbteglap = 0;
			double legnagyobbharom = 0;
			for (int i = 0; i < alakzatok.Length; i++)
			{
				if (alakzatok[i] is Kor)
				{
					legnagyobbkor = alakzatok[i].Ter;
				}
				else if (alakzatok[i] is Teglalap)
				{
					legnagyobbteglap = alakzatok[i].Ter;
				}
				else if (alakzatok[i] is Haromszog)
				{
					legnagyobbharom = alakzatok[i].Ter;
				}
			}

			for (int i = 0; i < alakzatok.Length; i++)
			{
				if (alakzatok[i] is Kor)
				{
					for (int j = 0; j < alakzatok.Length; j++)
					{
						if ((alakzatok[j] is Kor) && (alakzatok[j].Ter > alakzatok[i].Ter))
						{
							legnagyobbkor = alakzatok[j].Ter;
						}
					}
				}

				else if (alakzatok[i] is Teglalap)
				{
					for (int j = 0; j < alakzatok.Length; j++)
					{
						if ((alakzatok[j] is Teglalap) && (alakzatok[j].Ter > alakzatok[i].Ter))
						{
							legnagyobbteglap = alakzatok[j].Ter;
						}
					}
				}

				else if (alakzatok[i] is Haromszog)
				{
					for (int j = 0; j < alakzatok.Length; j++)
					{
						if ((alakzatok[j] is Haromszog) && (alakzatok[j].Ter > alakzatok[i].Ter))
						{
							legnagyobbharom = alakzatok[j].Ter;
						}
					}
				}
			}

			if (legnagyobbkor > 0)
			{
				Console.WriteLine("A legnagyobb területű kör: " + legnagyobbkor);
			}

			if (legnagyobbteglap > 0)
			{
				Console.WriteLine("A legnagyobb területű kör: " + legnagyobbteglap);
			}

			if (legnagyobbharom > 0)
			{
				Console.WriteLine("A legnagyobb területű kör: " + legnagyobbharom);
			}

			if (!felvettek.Contains("KÖR"))
			{
				Console.WriteLine("Nem vettél fel kört!");
			}

			else if (!felvettek.Contains("TÉGLALAP"))
			{
				Console.WriteLine("Nem vettél fel téglalapot!");
			}

			else if (!felvettek.Contains("HÁROMSZÖG"))
			{
				Console.WriteLine("Nem vettél fel háromszöget!");
			}

			Console.ReadKey();
		}
	}
}
