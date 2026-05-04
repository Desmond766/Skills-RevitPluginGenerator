---
kind: type
id: T:Autodesk.Revit.DB.Binding
source: html/47f6ad6f-8d00-af57-995e-dc6db1255f58.htm
---
# Autodesk.Revit.DB.Binding

Binding objects are used to take a parameter definition and bind it to one or
more categories.

## Syntax (C#)
```csharp
public abstract class Binding : APIObject
```

## Remarks
This class is a base class for all types of parameter binding within Autodesk
Revit. Once the binding objects are created and added to the document parameters will be
added to elements in those categories specified in the binding. There are currently two
types of binding available, Instance binding and Type binding. The key difference between
the two is that the instance bound parameters appear on all instances of the elements in
those categories. Changing the parameter on one does not affect the other instances of
the parameter. The Type bound parameters appear only on the type object and is shared by
all the instances that use that type. Changing the type bound parameter affects all
instances of the elements that use that type. Note, a definition can only be bound to an
instance or a type and not both.

