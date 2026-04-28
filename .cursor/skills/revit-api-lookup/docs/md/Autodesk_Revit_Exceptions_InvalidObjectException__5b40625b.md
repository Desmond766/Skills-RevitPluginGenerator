---
kind: type
id: T:Autodesk.Revit.Exceptions.InvalidObjectException
source: html/8092dec2-113a-0823-1a09-a46c11f99fea.htm
---
# Autodesk.Revit.Exceptions.InvalidObjectException

The exception that is thrown when referencing an object that is no longer valid.

## Syntax (C#)
```csharp
[SerializableAttribute]
public class InvalidObjectException : InvalidOperationException
```

## Remarks
The object may no longer exist for many reasons:
 The object was explicitly deleted from the database. A change to other database items caused the item to be automatically deleted from the database. The object no longer exists as its creation was undone (by rolling a transaction back).

