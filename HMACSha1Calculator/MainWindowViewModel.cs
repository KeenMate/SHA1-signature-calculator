using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using HMACSha1Calculator.Annotations;

namespace HMACSha1Calculator
{
	class MainWindowViewModel : INotifyPropertyChanged
	{
		private string secret;
		private string payload;
		private string signature;
		public event PropertyChangedEventHandler PropertyChanged;

		public string Secret
		{
			get { return secret; }
			set
			{
				secret = value;
				OnPropertyChanged();
				RecalculateSignature();

			}
		}

		public string Payload
		{
			get { return payload; }
			set
			{
				payload = value;
				OnPropertyChanged();
				RecalculateSignature();
			}
		}

		public string Signature
		{
			get { return signature; }
			set
			{
				signature = value;
				OnPropertyChanged();
			}
		}

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private void RecalculateSignature()
		{
			if (string.IsNullOrEmpty(secret) || string.IsNullOrEmpty(payload))
			{
				Signature = "Please, put values to both fields (Secret and Payload)";
				return;
			}

			HMACSHA1 sha1 = new HMACSHA1(Encoding.UTF8.GetBytes(Secret));

			var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(Payload));

			Signature = ToHex(hash, true);
		}

		public static string ToHex(byte[] bytes, bool upperCase)
		{
			StringBuilder result = new StringBuilder(bytes.Length * 2);

			for (int i = 0; i < bytes.Length; i++)
				result.Append(bytes[i].ToString(upperCase ? "X2" : "x2"));

			return result.ToString();
		}

	}
}
