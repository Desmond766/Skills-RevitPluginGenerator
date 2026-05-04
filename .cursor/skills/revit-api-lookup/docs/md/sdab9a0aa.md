---
kind: method
id: M:Autodesk.Revit.DB.PrintSetup.SaveAs(System.String)
source: html/b2ff4be8-70c5-ea87-a9d4-e0b7c4af39c6.htm
---
# Autodesk.Revit.DB.PrintSetup.SaveAs Method

Save the current print setting to another print setting with the specified name.

## Syntax (C#)
```csharp
public bool SaveAs(
	string newName
)
```

## Parameters
- **newName** (`System.String`) - print setting name to be saved as.

## Returns
False if Save As operation fails, otherwise true.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the input newName already exists in current print setting list.

