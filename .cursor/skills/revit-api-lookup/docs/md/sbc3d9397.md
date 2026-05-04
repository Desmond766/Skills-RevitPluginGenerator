---
kind: method
id: M:Autodesk.Revit.DB.ExtensibleStorage.SchemaBuilder.VendorIdIsValid(System.String)
source: html/66fc864b-ed7a-c9f9-7eae-209a9aa5c1b6.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.SchemaBuilder.VendorIdIsValid Method

Checks whether the given vendor ID string is valid. A valid vendor ID string:
 1. Has a length of at least 4 characters and no more than 253 characters, and
 2. Contains only letters, digits, or any of the following special characters:
 ! " # & \ ( ) + , . - : ; < = > ? _ ` | ~

## Syntax (C#)
```csharp
public static bool VendorIdIsValid(
	string vendorId
)
```

## Parameters
- **vendorId** (`System.String`) - The vendor ID to check.

## Returns
True if the vendor ID is valid.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

