---
kind: method
id: M:Autodesk.Revit.DB.ExternalResourceLoadContext.CallingDocumentHasModelPath
source: html/26ac114f-ea77-ef90-5082-b25ed90adec5.htm
---
# Autodesk.Revit.DB.ExternalResourceLoadContext.CallingDocumentHasModelPath Method

Indicates whether the document requesting the external resource has a defined
 ModelPath.

## Syntax (C#)
```csharp
public bool CallingDocumentHasModelPath()
```

## Returns
True if the document has a defined ModelPath.

## Remarks
A project that is detached, or has not been saved to disk yet, will not have a ModelPath.

