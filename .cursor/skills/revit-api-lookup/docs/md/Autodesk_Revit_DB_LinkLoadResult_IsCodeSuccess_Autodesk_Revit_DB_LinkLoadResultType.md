---
kind: method
id: M:Autodesk.Revit.DB.LinkLoadResult.IsCodeSuccess(Autodesk.Revit.DB.LinkLoadResultType)
source: html/703ef1de-1fe5-dad6-da35-c0b8d8e5be8c.htm
---
# Autodesk.Revit.DB.LinkLoadResult.IsCodeSuccess Method

Check if load result code signifies success.

## Syntax (C#)
```csharp
public static bool IsCodeSuccess(
	LinkLoadResultType code
)
```

## Parameters
- **code** (`Autodesk.Revit.DB.LinkLoadResultType`) - Load result code to be verified.

## Returns
True if LinkLoadResultType argument is success, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

