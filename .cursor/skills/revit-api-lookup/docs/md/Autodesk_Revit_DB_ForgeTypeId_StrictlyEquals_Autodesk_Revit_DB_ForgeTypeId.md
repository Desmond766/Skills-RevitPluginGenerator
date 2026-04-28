---
kind: method
id: M:Autodesk.Revit.DB.ForgeTypeId.StrictlyEquals(Autodesk.Revit.DB.ForgeTypeId)
source: html/adb6c8db-fc41-8f05-f400-0e655acae9f4.htm
---
# Autodesk.Revit.DB.ForgeTypeId.StrictlyEquals Method

Returns true if the entire typeid string held by this ForgeTypeId is exactly equal to that held by the given
 ForgeTypeId.
For the default equality comparison used by the equality operator (==), see
 NameEquals(ForgeTypeId) .

## Syntax (C#)
```csharp
public bool StrictlyEquals(
	ForgeTypeId other
)
```

## Parameters
- **other** (`Autodesk.Revit.DB.ForgeTypeId`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

