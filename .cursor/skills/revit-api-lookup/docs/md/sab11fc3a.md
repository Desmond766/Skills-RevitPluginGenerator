---
kind: method
id: M:Autodesk.Revit.DB.CustomExporter.IsRenderingSupported
source: html/50882930-42d7-5d6c-f70c-c5f665b22900.htm
---
# Autodesk.Revit.DB.CustomExporter.IsRenderingSupported Method

Checks if view rendering is currently supported in the running instance of Revit.

## Syntax (C#)
```csharp
public static bool IsRenderingSupported()
```

## Returns
Returns True if rendering is currently supported, False otherwise.

## Remarks
A typical reason for rendering not being enabled is when rendering and material
 libraries are not currently available in the installed copy of Revit.

