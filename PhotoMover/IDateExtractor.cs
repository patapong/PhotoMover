using System;

namespace PhotoMover
{
    public interface IDateExtractor
    {
        /// <summary>
        /// The name of the extractor. It will be used to identify the date extractor, make sure it's unique.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Get the date value when the photo was taken. can return optional extra infomation if you want.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        DateTime GetDate(string filePath, out string info);

        /// <summary>
        /// Add the extractor plugin into the application's extractor list, add the extension the plugin can support to the internal list.
        /// </summary>
        void Register();
    }

}
