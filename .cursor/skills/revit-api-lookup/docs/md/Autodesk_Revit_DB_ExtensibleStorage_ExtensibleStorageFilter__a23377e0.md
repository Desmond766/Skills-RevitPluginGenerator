---
kind: type
id: T:Autodesk.Revit.DB.ExtensibleStorage.ExtensibleStorageFilter
source: html/81cb1798-3dbe-658b-5a04-d97aa2cb4de9.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.ExtensibleStorageFilter

A filter used to filter elements with extensible storage data based on specific Schema id.

## Syntax (C#)
```csharp
public class ExtensibleStorageFilter : ElementQuickFilter
```

## Remarks
This filter is a quick filter.
 Quick filters operate only on the ElementRecord, a low-memory class which has
 a limited interface to read element properties. Elements which are rejected
 by a quick filter will not be expanded in memory.

