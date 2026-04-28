---
kind: type
id: T:Autodesk.Revit.DB.ElementOwnerViewFilter
source: html/cfaecf4c-b6b9-1481-de4f-e8d74e743911.htm
---
# Autodesk.Revit.DB.ElementOwnerViewFilter

A filter used to match elements which are owned by a particular view.

## Syntax (C#)
```csharp
public class ElementOwnerViewFilter : ElementQuickFilter
```

## Remarks
This filter is a quick filter.
 Quick filters operate only on the ElementRecord, a low-memory class which has
 a limited interface to read element properties. Elements which are rejected
 by a quick filter will not be expanded in memory.

