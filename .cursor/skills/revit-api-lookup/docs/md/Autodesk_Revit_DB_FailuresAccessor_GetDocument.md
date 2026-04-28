---
kind: method
id: M:Autodesk.Revit.DB.FailuresAccessor.GetDocument
source: html/f19901b5-9cba-bdbb-10a6-4ced16d2605f.htm
---
# Autodesk.Revit.DB.FailuresAccessor.GetDocument Method

Provides access to a document for which failures are being processed or preprocessed.

## Syntax (C#)
```csharp
public Document GetDocument()
```

## Returns
The document for which failures preprocessing or processing is being performed.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailuresAccessor is inactive (is used outside of failures processing).

