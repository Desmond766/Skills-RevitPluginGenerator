---
kind: method
id: M:Autodesk.Revit.DB.FamilyInstance.GetReferenceByName(System.String)
zh: 族实例
source: html/d44a95cc-f2c7-1fa9-9180-fefed6d70ed6.htm
---
# Autodesk.Revit.DB.FamilyInstance.GetReferenceByName Method

**中文**: 族实例

Gets the family instance reference corresponding to the named reference plane in the instance's family.

## Syntax (C#)
```csharp
public Reference GetReferenceByName(
	string name
)
```

## Parameters
- **name** (`System.String`) - The name of the reference plane in the family.

## Returns
Returns the family instance reference corresponding to the named reference plane in the instance's family.
 Returns null if there is no reference plane with this name in the family, or if the plane exists but its "Is Reference" property is "Not a Reference",
 or if the input string is empty.

## Remarks
If there is a reference plane in the instance's family that has the given name, and the plane's "Is Reference" property is not "Not a Reference",
 there will be a corresponding reference in the family's instance. This function returns that reference.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

