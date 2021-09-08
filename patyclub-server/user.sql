-- Table: public.User

-- DROP TABLE public."User";

CREATE TABLE IF NOT EXISTS public."User"
(
    id integer,
    name text COLLATE pg_catalog."default",
    phone text COLLATE pg_catalog."default",
    remark text COLLATE pg_catalog."default"
)

TABLESPACE pg_default;

ALTER TABLE public."User"
    OWNER to postgres;


TRUNCATE TABLE public."User";

INSERT INTO public."User" (id, name, phone, remark) VALUES (0, 'John', '07-3325-4125', '');
INSERT INTO public."User" (id, name, phone, remark) VALUES (1, 'Jenny', '085-331-621', '');
INSERT INTO public."User" (id, name, phone, remark) VALUES (2, 'Charles', '0800-092-000', '');
INSERT INTO public."User" (id, name, phone, remark) VALUES (3, 'Jean', '0800-000-123', '');
INSERT INTO public."User" (id, name, phone, remark) VALUES (4, 'Pong', '02-3939-889', '');