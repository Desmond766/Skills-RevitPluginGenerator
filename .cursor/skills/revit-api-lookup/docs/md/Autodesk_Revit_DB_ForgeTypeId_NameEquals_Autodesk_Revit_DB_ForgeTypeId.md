---
kind: method
id: M:Autodesk.Revit.DB.ForgeTypeId.NameEquals(Autodesk.Revit.DB.ForgeTypeId)
source: html/b5c290aa-702e-6f2c-8873-7d66cdf9522c.htm
---
# Autodesk.Revit.DB.ForgeTypeId.NameEquals Method

Returns true if the typeid string held by this ForgeTypeId is equal to that held by the given ForgeTypeId,
 excluding the version number. The version number of a typeid string follows a hyphen character. This function
 compares the typeid strings up to the first hyphen. This is the default equality comparison method for the
 ForgeTypeId class, used by the equality operator (==).

## Syntax (C#)
```csharp
public bool NameEquals(
	ForgeTypeId other
)
```

## Parameters
- **other** (`Autodesk.Revit.DB.ForgeTypeId`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

