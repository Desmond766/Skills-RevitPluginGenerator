---
kind: method
id: M:Autodesk.Revit.DB.SynchronizeWithCentralOptions.GetRelinquishOptions
source: html/445e3c8a-6a98-0c88-a5f7-7c38d0d57fec.htm
---
# Autodesk.Revit.DB.SynchronizeWithCentralOptions.GetRelinquishOptions Method

Gets the options which govern whether or not to relinquish elements and workset types.

## Syntax (C#)
```csharp
public RelinquishOptions GetRelinquishOptions()
```

## Returns
The options. If Nothing nullptr a null reference ( Nothing in Visual Basic) , synchronize with central will relinquish the current user's ownership of all worksets and all elements.

