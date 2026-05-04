---
kind: method
id: M:Autodesk.Revit.DB.LinearArray.IsElementArrayable(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/c7a9d13d-f660-659d-732b-13718d298e8a.htm
---
# Autodesk.Revit.DB.LinearArray.IsElementArrayable Method

Indicates whether the input element is arrayable.

## Syntax (C#)
```csharp
public static bool IsElementArrayable(
	Document aDoc,
	ElementId id
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - The document.
- **id** (`Autodesk.Revit.DB.ElementId`) - The element id.

## Returns
True if the input element is arrayable, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

