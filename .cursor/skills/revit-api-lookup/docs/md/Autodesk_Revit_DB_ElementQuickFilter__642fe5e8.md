---
kind: type
id: T:Autodesk.Revit.DB.ElementQuickFilter
source: html/ebc95d82-11fc-69f6-2df1-52331dd36443.htm
---
# Autodesk.Revit.DB.ElementQuickFilter

A base class for a type of filter that operates on element records.

## Syntax (C#)
```csharp
public class ElementQuickFilter : ElementFilter
```

## Remarks
Quick filters operate only on the ElementRecord, a low-memory class which has
 a limited interface to read element properties. Elements which are rejected
 by a quick filter will not be expanded in memory.

