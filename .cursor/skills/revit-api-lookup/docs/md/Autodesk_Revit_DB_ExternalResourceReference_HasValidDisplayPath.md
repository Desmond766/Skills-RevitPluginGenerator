---
kind: method
id: M:Autodesk.Revit.DB.ExternalResourceReference.HasValidDisplayPath
source: html/a79b2db7-2ef5-fd11-71e2-ecfc84f3acc5.htm
---
# Autodesk.Revit.DB.ExternalResourceReference.HasValidDisplayPath Method

Checks whether this external Resource has a valid display path.

## Syntax (C#)
```csharp
public bool HasValidDisplayPath()
```

## Returns
True if the this external Resource has a valid display path. False otherwise.

## Remarks
For an external resource, such as a Revit link loaded from an external server, the valid display path
 should be like "My Server://Nested/Nested_1.rvt".
 For an external resource, such as a Revit link loaded from the "built-in" server, the valid display path
 should be like "c:\LocalLinks\Link_1.rvt".

