---
kind: method
id: M:Autodesk.Revit.DB.SynchronizeWithCentralOptions.SetRelinquishOptions(Autodesk.Revit.DB.RelinquishOptions)
source: html/0ebff269-60c0-6907-b6a9-45cec4e0e447.htm
---
# Autodesk.Revit.DB.SynchronizeWithCentralOptions.SetRelinquishOptions Method

Sets the options which govern whether or not to relinquish elements and workset types.

## Syntax (C#)
```csharp
public void SetRelinquishOptions(
	RelinquishOptions relinquishOptions
)
```

## Parameters
- **relinquishOptions** (`Autodesk.Revit.DB.RelinquishOptions`) - The options. If Nothing nullptr a null reference ( Nothing in Visual Basic) , synchronize with central will relinquish the current user's ownership of all worksets and all elements.

