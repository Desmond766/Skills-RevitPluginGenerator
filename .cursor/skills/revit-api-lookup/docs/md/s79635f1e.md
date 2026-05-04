---
kind: method
id: M:Autodesk.Revit.DB.IExternalResourceServer.GetIconPath
source: html/f4fbc146-9124-8a4f-28cd-6d750efd5304.htm
---
# Autodesk.Revit.DB.IExternalResourceServer.GetIconPath Method

Implement this method to return the path to an icon file which will be displayed in Revit
 user interfaces associated to this server.

## Syntax (C#)
```csharp
string GetIconPath()
```

## Returns
The image file of the server.

## Remarks
The specified image will be displayed in the browser dialogs when the user is selecting
 a resource of a compatible type. The return must be the full path to an icon file containing 48x48, 32x32 and 16x16 pixel images. If this method returns anything other than a valid icon file, a default image will be used for the server.

