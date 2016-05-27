using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Drawing;

using System.Drawing.Imaging;

using System.Data.SqlClient;
using System.Collections;
using System.Web.Configuration;
using System.Data;


namespace Business
{
    public static class Utility
    {
        

        #region Get Root Path
        public static String RootPath
        {
            get { return System.Configuration.ConfigurationSettings.AppSettings["RootPath"].ToString(); }

        }

        #endregion

        #region Generate Thumbnail

        public static String GenerateThumb(String TargetFilePath, String SourceFilePath, int height, int width)
        {
            int thumb_width = width; int thumb_height = height;

            Bitmap source_bitmap = new Bitmap(SourceFilePath);
            Bitmap thumb_bitmap = new Bitmap(thumb_width, thumb_height);
            Graphics g = Graphics.FromImage(thumb_bitmap);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.FillRectangle(Brushes.White, 0, 0, thumb_width, thumb_height);
            g.DrawImage(source_bitmap, 0, 0, thumb_width, thumb_height);

            ImageCodecInfo[] Info = ImageCodecInfo.GetImageEncoders();
            EncoderParameters Params = new EncoderParameters(1);
            Params.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
            thumb_bitmap.Save(TargetFilePath, Info[1], Params);
            string FileName = TargetFilePath;
            return FileName;


            //System.Drawing.Image objImage;
            //System.Drawing.Image objThumbnail;
            //string strThumbFileName;


            //objImage = System.Drawing.Image.FromFile(SourceFilePath);
            //objThumbnail = objImage.GetThumbnailImage(width, height, null, System.IntPtr.Zero);

            //strThumbFileName = FileName;
            //objThumbnail.Save(strThumbFileName, System.Drawing.Imaging.ImageFormat.Jpeg);



            //objImage.Dispose();

        }
        //public static void GenerateThumb(String TargetFilePath, String SourceFilePath, string filename, int height, int width)
        //{




        //    System.Drawing.Bitmap _objImage;
        //    System.Drawing.Bitmap _objThumbnail;
        //    _objImage = (Bitmap)System.Drawing.Bitmap.FromFile(SourceFilePath);

        //    Bitmap outputImage = new Bitmap(_objImage, 100, 100);
        //    outputImage.SetResolution(96, 96);
        //    outputImage.Save(TargetFilePath + filename, System.Drawing.Imaging.ImageFormat.Jpeg); 
        //  //_objThumbnail = (Bitmap)_objImage.GetThumbnailImage(width, width, null, System.IntPtr.Zero);
        //  //_objThumbnail.SetResolution(96, 96);

        //   // _objThumbnail.Save(TargetFilePath + filename, System.Drawing.Imaging.ImageFormat.Jpeg);

        //    _objImage.Dispose();
        //    //System.Drawing.Image objImage;
        //    //System.Drawing.Image objThumbnail;
        //    //objImage = System.Drawing.Image.FromFile(SourceFilePath);
        //    //objThumbnail = objImage.GetThumbnailImage(width, height, null, System.IntPtr.Zero);

        //    //objThumbnail.Save(TargetFilePath + filename, System.Drawing.Imaging.ImageFormat.Jpeg);
        //    //objImage.Dispose();

        //}
        #endregion

  




    }
}
