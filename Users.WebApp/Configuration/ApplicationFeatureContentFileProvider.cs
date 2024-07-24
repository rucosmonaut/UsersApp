namespace Users.WebApp.Configuration;

using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.FileProviders.Physical;
using Microsoft.Extensions.Primitives;

public class ApplicationFeatureContentFileProvider
    : IFileProvider
{
    private static readonly char[] _pathSeparators = {
        Path.DirectorySeparatorChar,
        Path.AltDirectorySeparatorChar
    };

    private readonly string rootFolder;

    public ApplicationFeatureContentFileProvider(
        string rootFolder)
    {
        this.rootFolder = rootFolder;
    }

    public IDirectoryContents GetDirectoryContents(
        string subpath)
    {
        throw new NotImplementedException();
    }

    public IFileInfo GetFileInfo(
        string subpath)
    {
        if (string.IsNullOrEmpty(value: subpath))
        {
            return new NotFoundFileInfo(
                name: subpath);
        }

        var fileInfo = new FileInfo(
            fileName: Path.Combine(
                path1: this.rootFolder,
                path2: subpath.TrimStart(
                    trimChars: _pathSeparators)));

        return new PhysicalFileInfo(
            info: fileInfo);
    }

    public IChangeToken Watch(
        string filter)
    {
        throw new NotImplementedException();
    }
}
