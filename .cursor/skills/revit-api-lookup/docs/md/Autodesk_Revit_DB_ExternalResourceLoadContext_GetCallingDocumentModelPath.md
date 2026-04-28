---
kind: method
id: M:Autodesk.Revit.DB.ExternalResourceLoadContext.GetCallingDocumentModelPath
source: html/aafcfaf8-26e8-2e08-c56f-fd500e2add52.htm
---
# Autodesk.Revit.DB.ExternalResourceLoadContext.GetCallingDocumentModelPath Method

Returns a copy of the ModelPath of the document that is requesting
 the external resource.

## Syntax (C#)
```csharp
public ModelPath GetCallingDocumentModelPath()
```

## Returns
A copy of the ModelPath of the document that is requesting the external
 resource.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The document requesting the external resource does not have a ModelPath, either because
 it is detached, or because it has not been saved to disk yet.

