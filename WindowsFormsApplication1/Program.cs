//
// vs2013 OpenCv.netの環境構築用のサンプル
//
// コードは以下のサイトのものを使わせて頂きました。
//
// NuGetでOpenCv.Netを入れるだけで使えるので凄いね。Imageの変換とかもしなくていいし...
// でも情報はすくないかも
//
// http://whoopsidaisies.hatenablog.com/entry/2013/10/25/005953
//
//


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            
            // ファイルから画像読み込み
            var img = OpenCV.Net.CV.LoadImage(@"C:\Users\como\Desktop\色サンプル\00-top_m.png", OpenCV.Net.LoadImageFlags.AnyColor);
            // エッジ画像格納用の変数作成
            var dst = img.Clone();

            // sobelフィルタ適用
            OpenCV.Net.CV.Sobel(img, dst, 1, 1);

            // 原画用のウインドウ生成
            var windowOrg = new OpenCV.Net.NamedWindow("原画");
            // 原画表示
            windowOrg.ShowImage(img);
            // エッジ用のウィンドウ生成
            var windowEdge = new OpenCV.Net.NamedWindow("エッジ");
            // エッジ表示
            windowEdge.ShowImage(dst);

            // キー入力待ち
            OpenCV.Net.CV.WaitKey(0);
        }
    }
}
