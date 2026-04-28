---
kind: method
id: M:Autodesk.Revit.DB.ExternalResourceBrowserData.GetCallingDocumentModelPath
source: html/7a877029-3b5a-3de8-9c35-fe38fa48c82e.htm
---
# Autodesk.Revit.DB.ExternalResourceBrowserData.GetCallingDocumentModelPath Method

Returns a copy of the ModelPath of the document that is requesting the external resource browser data.

## Syntax (C#)
```csharp
public ModelPath GetCallingDocumentModelPath()
```

## Returns
A copy of the ModelPath of the document that is requesting the external resource browser data.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The document requesting the external resource browser data does not have a ModelPath, either because
 it is detached, or because it has not been saved to disk yet, or no document specified.

