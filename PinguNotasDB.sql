CREATE TABLE usuarios (
    id SERIAL PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    password VARCHAR(255) NOT NULL
);

CREATE TABLE notas (
    id SERIAL PRIMARY KEY,
    titulo VARCHAR(255) NOT NULL,
    contenido JSONB,
    fecha_creacion TIMESTAMP DEFAULT NOW(),
    usuario_id INTEGER REFERENCES usuarios(id),
    es_publica BOOLEAN DEFAULT FALSE -- Falta la coma en el esquema original
);

CREATE TABLE etiquetas (
    id SERIAL PRIMARY KEY,
    nombre VARCHAR(50) UNIQUE NOT NULL,
    color VARCHAR(50) CHECK (color ~ '^#[0-9A-Fa-f]{6}$') -- Falta la coma en el esquema original
);

CREATE TABLE notas_etiquetas (
    nota_id INTEGER REFERENCES notas(id),
    etiqueta_id INTEGER REFERENCES etiquetas(id),
    PRIMARY KEY (nota_id, etiqueta_id)
);
