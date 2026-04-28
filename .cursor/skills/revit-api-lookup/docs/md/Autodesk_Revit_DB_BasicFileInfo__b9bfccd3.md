---
kind: type
id: T:Autodesk.Revit.DB.BasicFileInfo
source: html/475edc09-cee7-6ff1-a0fa-4e427a56262a.htm
---
# Autodesk.Revit.DB.BasicFileInfo

Encapsulates basic information about a Revit file, including worksharing status, Revit version, username and central path.

## Syntax (C#)
```csharp
public class BasicFileInfo : IDisposable
```

## Remarks
This class provides a fast access to get basic information without fully opening a Revit file. The
 Extract method
 can initialize a new instance of this class by providing a full path for Revit file, including project (.rvt) and family (.rfa) files.
 This class can extract information from files of older formats.
 If the structure of the BasicFileInfo storage has not changed,
 it can also extract information from files of newer formats
 (making the method IsSavedInLaterVersion relevant).
 However, if the structure of the storage has changed in a newer file format,
 Extract will not be able to extract the information.

