namespace SubC.AllegroDotNet.Native;

internal partial class Context
{
  public CoreApi Core => _core ??= new();
  public ImageAddon Image => _image ??= new();

  private CoreApi? _core;
  private ImageAddon? _image;
}