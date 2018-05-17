using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Webjs.src;

namespace Webjs.Parser.NewsParser
{
    class ParserWorker<T> where T : class
    {
        IParser<T> parser;
        ISettings settings;
        HtmlLoader HtmlLoader;
        private bool _isActiv = false;

        public bool IsActiv => _isActiv;

        public IParser<T> Parser { get { return parser; } set { parser = value; } }

        public ISettings Settings { get => settings; set { settings = value; HtmlLoader = new HtmlLoader(value); } }

        public event Action<object, T> OnNewData;
        public event Action<object> OnComleted;

        public ParserWorker(IParser<T> parser)
        {
            this.parser = parser;
        }

        public ParserWorker(IParser<T> parser, ISettings settings) : this(parser)
        {
            this.settings = settings;
        }

        public void Start()
        {
         Worker();
            _isActiv = true;
        }

        public void Abort()
        {
            _isActiv = false;
        }

        private async void Worker()
        {
            for (int i = settings.StartPoint; i < settings.Endpoint; i++)
            {
                if (_isActiv)
                {
                    OnComleted?.Invoke(this);
                    return;
                }

                var source = await HtmlLoader.GetSourseById(i);
                var domParser = new HtmlParser();

                var document = await domParser.ParseAsync(source);

                var result =parser.Parser(document);

                OnNewData?.Invoke(this, result);
            }

            OnComleted?.Invoke(this);
            _isActiv = false;
        }
    }
}
