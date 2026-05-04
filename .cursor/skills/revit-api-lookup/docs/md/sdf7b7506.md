---
kind: method
id: M:Autodesk.Revit.DB.ExternalResourceBrowserData.CallingDocumentHasModelPath
source: html/7c19b745-83f6-24c9-43e9-0a160eab123b.htm
---
# Autodesk.Revit.DB.ExternalResourceBrowserData.CallingDocumentHasModelPath Method

Indicates whether the document requesting the external resource browser data has a defined ModelPath.

## Syntax (C#)
```csharp
public bool CallingDocumentHasModelPath()
```

## Returns
True if the document has a defined ModelPath.

## Remarks
A project that is detached, or has not been saved to disk yet, will not have a ModelPath.

