using System;

namespace ECommercePlatform.Models
{
    public enum UserRole
    {
        CUSTOMER,
        VENDOR,
        DRIVER,
        ADMIN,
        SUPPORT
    }

    public enum VendorType
    {
        PHARMACY,
        RESTAURANT,
        GIFT_SHOP,
        GROCERY,
        SPECIALTY_STORE
    }

    public enum ProductCategory
    {
        FOOD,
        PHARMACY,
        GIFTS,
        GROCERIES,
        ELECTRONICS,
        CLOTHING,
        BOOKS,
        FLOWERS
    }

    public enum OrderStatus
    {
        PENDING,
        CONFIRMED,
        PREPARING,
        READY_FOR_PICKUP,
        PICKED_UP,
        IN_TRANSIT,
        OUT_FOR_DELIVERY,
        DELIVERED,
        CANCELLED,
        REFUNDED
    }

    public enum PaymentMethod
    {
        CREDIT_CARD,
        DEBIT_CARD,
        PAYPAL,
        BANK_TRANSFER,
        MOBILE_WALLET,
        CASH_ON_DELIVERY,
        CRYPTOCURRENCY
    }

    public enum PaymentStatus
    {
        PENDING,
        PROCESSING,
        COMPLETED,
        FAILED,
        REFUNDED,
        CANCELLED
    }

    public enum ShipmentType
    {
        LOCAL_DELIVERY,
        CROSS_BORDER,
        EXPRESS_DELIVERY,
        SAME_DAY,
        SCHEDULED_DELIVERY
    }

    public enum ShipmentStatus
    {
        PENDING,
        ASSIGNED,
        PICKED_UP,
        IN_TRANSIT,
        IN_CUSTOMS,
        OUT_FOR_DELIVERY,
        DELIVERED,
        FAILED_DELIVERY
    }

    public enum PackageStatus
    {
        PENDING,
        COLLECTING,
        READY_TO_SHIP,
        IN_CUSTOMS,
        SHIPPED,
        DELIVERED,
        CANCELLED
    }

    public enum NotificationType
    {
        ORDER_CONFIRMATION,
        STATUS_UPDATE,
        DELIVERY_NOTIFICATION,
        PAYMENT_CONFIRMATION,
        PROMOTION_ALERT,
        SYSTEM_NOTIFICATION
    }

    public enum CouponType
    {
        PERCENTAGE_DISCOUNT,
        FIXED_AMOUNT,
        FREE_SHIPPING,
        BUY_ONE_GET_ONE,
        MINIMUM_ORDER_DISCOUNT,
        CATEGORY_SPECIFIC,
        VENDOR_SPECIFIC,
        FIRST_ORDER_DISCOUNT,
        LOYALTY_REWARD
    }

    public enum OfferType
    {
        FLASH_SALE,
        SEASONAL_OFFER,
        BULK_DISCOUNT,
        COMBO_OFFER,
        CLEARANCE_SALE,
        NEW_CUSTOMER_OFFER,
        LOYALTY_OFFER,
        VENDOR_PROMOTION,
        CATEGORY_SALE,
        TIME_LIMITED
    }

    public enum AdminLevel
    {
        SUPER_ADMIN,
        SYSTEM_ADMIN,
        OPERATIONS_ADMIN,
        CUSTOMER_SUPPORT,
        CONTENT_MODERATOR
    }
}
