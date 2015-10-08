using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using FlexCharts.Controls.Core;
using FlexCharts.Helpers.DependencyHelpers;

namespace Material.Controls
{
	public class QualifiedCodeSpan : DependencyObject
	{
		public static readonly DependencyProperty TextProperty = DP.Register(
			new Meta<QualifiedCodeSpan, string>());
		public string Text
		{
			get { return (string) GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}
		public static readonly DependencyProperty ForegroundProperty = DP.Register(
			new Meta<QualifiedCodeSpan, SolidColorBrush>());
		public SolidColorBrush Foreground
		{
			get { return (SolidColorBrush) GetValue(ForegroundProperty); }
			set { SetValue(ForegroundProperty, value); }
		}

		public QualifiedCodeSpan(string text, SolidColorBrush foreground)
		{
			Text = text;
			Foreground = foreground;
		}
	}
	public class XMLTextEditor : FlexControl
	{
		public static readonly DependencyProperty SourceFileProperty = DP.Register(
			new Meta<XMLTextEditor, FileInfo>(null, SourceFileChanged));

		private static void SourceFileChanged(XMLTextEditor i, DPChangedEventArgs<FileInfo> e)
		{
			i.colorize();
		}

		public FileInfo SourceFile
		{
			get { return (FileInfo) GetValue(SourceFileProperty); }
			set { SetValue(SourceFileProperty, value); }
		}

		public static readonly DependencyProperty CodeVisualProperty = DP.Register(
			new Meta<XMLTextEditor, ObservableCollection<QualifiedCodeSpan>>());
		public ObservableCollection<QualifiedCodeSpan> CodeVisual
		{
			get { return (ObservableCollection<QualifiedCodeSpan>) GetValue(CodeVisualProperty); }
			set { SetValue(CodeVisualProperty, value); }
		}

		private RichTextBox PART_rtb;
		static XMLTextEditor()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof (XMLTextEditor), new FrameworkPropertyMetadata(typeof (XMLTextEditor)));
		}

		public XMLTextEditor()
		{
			CodeVisual = new ObservableCollection<QualifiedCodeSpan>();
		}
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			PART_rtb = GetTemplateChild<RichTextBox>(nameof(PART_rtb));
			//PART_rtb.
		}

		private void colorize()
		{
			var documentString = File.ReadAllText(SourceFile.FullName);
			var docCharArray = documentString.ToCharArray();
			var buffer = "";
			foreach (var c in docCharArray)
			{
				switch (c)
				{
					case '<':
						CodeVisual.Add(new QualifiedCodeSpan(buffer, Brushes.Aquamarine));
						buffer = "";
						CodeVisual.Add(new QualifiedCodeSpan("<", Brushes.White));
						break;
					default:
						buffer += c;
						break;
				}
			}
			//for(var i = 0; i < documentString.Length; i++)
			//{
			//	var currentChar = documentString.ToCharArray()
			//}
		}
	}
}
