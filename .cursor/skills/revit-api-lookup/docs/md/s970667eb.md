---
kind: method
id: M:Autodesk.Revit.DB.AddInId.GetAddInNameFromDocument(Autodesk.Revit.DB.Document)
source: html/77a62604-7055-b459-486f-11f917ec922d.htm
---
# Autodesk.Revit.DB.AddInId.GetAddInNameFromDocument Method

name of application associated with this ApplicationId
 First attempts to obtain the name from AddInIds stored in the document.
 If unsuccessful, attempts to obtain the name from loaded Third Party AddIns.

## Syntax (C#)
```csharp
public string GetAddInNameFromDocument(
	Document aDoc
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - target document

## Returns
name of application

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL

