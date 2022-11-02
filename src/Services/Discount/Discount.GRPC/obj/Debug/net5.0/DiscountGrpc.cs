// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/discount.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Discount.GRPC.Protos {
  public static partial class DiscountProtoSerivces
  {
    static readonly string __ServiceName = "DiscountProtoSerivces";

    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    static readonly grpc::Marshaller<global::Discount.GRPC.Protos.GetDiscountRequest> __Marshaller_GetDiscountRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Discount.GRPC.Protos.GetDiscountRequest.Parser));
    static readonly grpc::Marshaller<global::Discount.GRPC.Protos.CouponModel> __Marshaller_CouponModel = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Discount.GRPC.Protos.CouponModel.Parser));
    static readonly grpc::Marshaller<global::Discount.GRPC.Protos.CreateDiscountRequest> __Marshaller_CreateDiscountRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Discount.GRPC.Protos.CreateDiscountRequest.Parser));
    static readonly grpc::Marshaller<global::Discount.GRPC.Protos.UpdateDiscountRequest> __Marshaller_UpdateDiscountRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Discount.GRPC.Protos.UpdateDiscountRequest.Parser));
    static readonly grpc::Marshaller<global::Discount.GRPC.Protos.DeleteDiscountRequest> __Marshaller_DeleteDiscountRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Discount.GRPC.Protos.DeleteDiscountRequest.Parser));
    static readonly grpc::Marshaller<global::Discount.GRPC.Protos.DeleteDiscountResponse> __Marshaller_DeleteDiscountResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Discount.GRPC.Protos.DeleteDiscountResponse.Parser));

    static readonly grpc::Method<global::Discount.GRPC.Protos.GetDiscountRequest, global::Discount.GRPC.Protos.CouponModel> __Method_GetDiscount = new grpc::Method<global::Discount.GRPC.Protos.GetDiscountRequest, global::Discount.GRPC.Protos.CouponModel>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetDiscount",
        __Marshaller_GetDiscountRequest,
        __Marshaller_CouponModel);

    static readonly grpc::Method<global::Discount.GRPC.Protos.CreateDiscountRequest, global::Discount.GRPC.Protos.CouponModel> __Method_CreateDiscount = new grpc::Method<global::Discount.GRPC.Protos.CreateDiscountRequest, global::Discount.GRPC.Protos.CouponModel>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateDiscount",
        __Marshaller_CreateDiscountRequest,
        __Marshaller_CouponModel);

    static readonly grpc::Method<global::Discount.GRPC.Protos.UpdateDiscountRequest, global::Discount.GRPC.Protos.CouponModel> __Method_UpdateDiscount = new grpc::Method<global::Discount.GRPC.Protos.UpdateDiscountRequest, global::Discount.GRPC.Protos.CouponModel>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateDiscount",
        __Marshaller_UpdateDiscountRequest,
        __Marshaller_CouponModel);

    static readonly grpc::Method<global::Discount.GRPC.Protos.DeleteDiscountRequest, global::Discount.GRPC.Protos.DeleteDiscountResponse> __Method_DeleteDiscount = new grpc::Method<global::Discount.GRPC.Protos.DeleteDiscountRequest, global::Discount.GRPC.Protos.DeleteDiscountResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteDiscount",
        __Marshaller_DeleteDiscountRequest,
        __Marshaller_DeleteDiscountResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Discount.GRPC.Protos.DiscountReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of DiscountProtoSerivces</summary>
    [grpc::BindServiceMethod(typeof(DiscountProtoSerivces), "BindService")]
    public abstract partial class DiscountProtoSerivcesBase
    {
      public virtual global::System.Threading.Tasks.Task<global::Discount.GRPC.Protos.CouponModel> GetDiscount(global::Discount.GRPC.Protos.GetDiscountRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Discount.GRPC.Protos.CouponModel> CreateDiscount(global::Discount.GRPC.Protos.CreateDiscountRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Discount.GRPC.Protos.CouponModel> UpdateDiscount(global::Discount.GRPC.Protos.UpdateDiscountRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Discount.GRPC.Protos.DeleteDiscountResponse> DeleteDiscount(global::Discount.GRPC.Protos.DeleteDiscountRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(DiscountProtoSerivcesBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetDiscount, serviceImpl.GetDiscount)
          .AddMethod(__Method_CreateDiscount, serviceImpl.CreateDiscount)
          .AddMethod(__Method_UpdateDiscount, serviceImpl.UpdateDiscount)
          .AddMethod(__Method_DeleteDiscount, serviceImpl.DeleteDiscount).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, DiscountProtoSerivcesBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetDiscount, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Discount.GRPC.Protos.GetDiscountRequest, global::Discount.GRPC.Protos.CouponModel>(serviceImpl.GetDiscount));
      serviceBinder.AddMethod(__Method_CreateDiscount, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Discount.GRPC.Protos.CreateDiscountRequest, global::Discount.GRPC.Protos.CouponModel>(serviceImpl.CreateDiscount));
      serviceBinder.AddMethod(__Method_UpdateDiscount, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Discount.GRPC.Protos.UpdateDiscountRequest, global::Discount.GRPC.Protos.CouponModel>(serviceImpl.UpdateDiscount));
      serviceBinder.AddMethod(__Method_DeleteDiscount, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Discount.GRPC.Protos.DeleteDiscountRequest, global::Discount.GRPC.Protos.DeleteDiscountResponse>(serviceImpl.DeleteDiscount));
    }

  }
}
#endregion
