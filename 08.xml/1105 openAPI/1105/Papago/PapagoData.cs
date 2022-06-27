using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1105
{
	class PapagoData
	{
		public Message message;
	}

	class Message
	{
		public Result result;
	}

	class Result
	{
		public string srcLangType;
		public string tarLangType;
		public string translatedText;
		public string engineType;
		public string PRETRANS;
		public string pivot;
	}

}
