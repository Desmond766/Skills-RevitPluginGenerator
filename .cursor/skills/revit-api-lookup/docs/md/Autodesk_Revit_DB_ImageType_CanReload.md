---
kind: method
id: M:Autodesk.Revit.DB.ImageType.CanReload
source: html/6090600f-8d4c-511d-a7c5-a21caf768bfc.htm
---
# Autodesk.Revit.DB.ImageType.CanReload Method

Check whether the ImageType can be reloaded from file.

## Syntax (C#)
```csharp
public bool CanReload()
```

## Returns
True if the ImageType can be reloaded. False, otherwise.

## Remarks
The test first determines the candidate path for reloading the ImageType. Then the test checks that the
 corresponding file is a valid image file, that it is unencrypted, and that it contains the page corresponding to PageNumber .

